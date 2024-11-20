import torch
import torch.nn as nn
import torch.optim as optim
import torchvision.transforms as transforms
import torchvision.datasets as datasets
from PIL import Image, ImageOps
import numpy as np


#파이참에서 .pth 신경망을 따로 테스트해 보았다.

# CNN 클래스 정의
class CNN(torch.nn.Module):
    def __init__(self):
        super(CNN, self).__init__()
        self.keep_prob = 0.5  # 드롭아웃 확률

        # L1: 첫 번째 합성곱층 (Conv Layer)
        self.layer1 = torch.nn.Sequential(
            torch.nn.Conv2d(1, 32, kernel_size=3, stride=1, padding=1),
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(kernel_size=2, stride=2))

        # L2: 두 번째 합성곱층 (Conv Layer)
        self.layer2 = torch.nn.Sequential(
            torch.nn.Conv2d(32, 64, kernel_size=3, stride=1, padding=1),
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(kernel_size=2, stride=2))

        # L3: 세 번째 합성곱층 (Conv Layer)
        self.layer3 = torch.nn.Sequential(
            torch.nn.Conv2d(64, 128, kernel_size=3, stride=1, padding=1),
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(kernel_size=2, stride=2, padding=1))

        # L4: 첫 번째 선형층 (Fully Connected Layer)
        self.fc1 = torch.nn.Linear(4 * 4 * 128, 625, bias=True)
        torch.nn.init.xavier_uniform_(self.fc1.weight)  # 가중치 초기화
        self.layer4 = torch.nn.Sequential(
            self.fc1,
            torch.nn.ReLU(),
            torch.nn.Dropout(p=1 - self.keep_prob))

        # L5: 최종 선형층 (Fully Connected Layer)
        self.fc2 = torch.nn.Linear(625, 10, bias=True)
        torch.nn.init.xavier_uniform_(self.fc2.weight)  # 가중치 초기화

    def forward(self, x):
        out = self.layer1(x)  # 첫 번째 합성곱층 통과
        out = self.layer2(out)  # 두 번째 합성곱층 통과
        out = self.layer3(out)  # 세 번째 합성곱층 통과
        out = out.view(out.size(0), -1)  # 선형층에 입력하기 위해 텐서를 Flatten
        out = self.layer4(out)  # 첫 번째 선형층 통과
        out = self.fc2(out)  # 최종 선형층 통과
        return out  # 최종 출력 반환

# 저장된 모델 불러오기
model = CNN()  # CNN 클래스는 이전에 정의한 네트워크입니다.
checkpoint = torch.load('C:/Users/shhawork/Code/AI/RNN/book01/cnn_model_v2.pth')  # 저장된 모델 불러오기
model.load_state_dict(checkpoint['model_state_dict'])

# 옵티마이저 설정 (저장된 옵티마이저 상태도 불러오기)
optimizer = optim.Adam(model.parameters())
optimizer.load_state_dict(checkpoint['optimizer_state_dict'])

# 평가 모드 설정
epoch = checkpoint['epoch']  # 마지막 저장된 에포크 번호
model.eval()  # 모델을 평가 모드로 설정

# 테스트 데이터를 위한 준비
test_dataset = datasets.MNIST(
    root='./data',
    train=False,
    transform=transforms.ToTensor(),  # 데이터를 텐서 형태로 변환
    download=True
)

test_loader = torch.utils.data.DataLoader(
    dataset=test_dataset,
    batch_size=64,
    shuffle=False
)

# 모델 테스트하기
def test_model(model, test_loader):
    correct = 0
    total = 0
    criterion = nn.CrossEntropyLoss()
    test_loss = 0.0

    with torch.no_grad():  # 테스트에서는 그래디언트 계산 필요 없음
        for images, labels in test_loader:
            outputs = model(images)  # 모델을 통해 예측 수행
            loss = criterion(outputs, labels)  # 손실 계산
            test_loss += loss.item()
            _, predicted = torch.max(outputs.data, 1)  # 가장 높은 값을 가진 클래스 예측
            total += labels.size(0)
            correct += (predicted == labels).sum().item()

    accuracy = 100 * correct / total
    avg_loss = test_loss / len(test_loader)
    print(f'정확도 테스트: {accuracy:.2f}%')
    print(f'평균 손실: {avg_loss:.4f}')

def predict_image(model, image_path):
    # 이미지 로드 및 전처리
    image = Image.open(image_path).convert('L')  # 그레이스케일로 변환
    image = ImageOps.invert(image)  # 색 반전 (검은 배경에 흰색 글씨로 변경)
    transform = transforms.Compose([
        transforms.Resize((28, 28)),
        transforms.ToTensor(),
        transforms.Normalize((0.5,), (0.5,))
    ])
    image = transform(image).unsqueeze(0)  # 배치 차원 추가

    # 모델을 사용하여 예측
    model.eval()
    with torch.no_grad():
        output = model(image)
        _, predicted = torch.max(output.data, 1)
        print(f'예상된 숫자값: {predicted.item()}')

    # 시각화를 통한 확인
    import matplotlib.pyplot as plt
    plt.imshow(image.squeeze(), cmap='gray')
    plt.title(f'Predict: {predicted.item()}')
    plt.show()

# 테스트 함수 실행
#test_model(model, test_loader)
# 사용자 지정 이미지 예측 실행
predict_image(model, 'C:/Temp/mnist/five.png')

data_iter = iter(test_loader)
images, labels = next(data_iter)

import matplotlib.pyplot as plt

# 첫 5개 이미지 시각화 및 예측
for idx in range(5):
    image = images[idx].unsqueeze(0)
    with torch.no_grad():
        output = model(image)
        _, predicted = torch.max(output.data, 1)

    plt.subplot(1, 5, idx + 1)
    plt.imshow(images[idx].squeeze(), cmap='gray')
    plt.title(f'Pred: {predicted.item()}')
    plt.axis('off')

plt.show()
