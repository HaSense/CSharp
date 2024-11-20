using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;


namespace ONNXFirstApp
{
    internal class Program
    {
        static DenseTensor<float> PreprocessImage(string imagePath)
        {
            // System.Drawing을 사용하여 이미지 로드 및 리사이즈
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                // 이미지를 28x28 크기로 리사이즈
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size(28, 28));

                // 픽셀 데이터를 float 배열로 변환하고 정규화
                float[] imageData = new float[1 * 1 * 28 * 28]; // 배치 크기 1, 채널 1, 28x28 이미지

                for (int y = 0; y < 28; y++)
                {
                    for (int x = 0; x < 28; x++)
                    {
                        // 흑백 이미지로 가정하고, Red 채널 값을 사용하여 정규화
                        Color pixel = resizedBitmap.GetPixel(x, y);
                        float pixelValue = 1.0f - (pixel.R / 255.0f); // 색 반전 (0-255 값을 1-0으로 반전 후 정규화)
                        imageData[y * 28 + x] = pixelValue;
                    }
                }

                // DenseTensor로 변환 (모델 입력 형식에 맞춰 [1, 1, 28, 28] 형태로 만듦)
                return new DenseTensor<float>(imageData, new int[] { 1, 1, 28, 28 });
            }
        }
        static float[] Softmax(float[] logits)
        {
            // 소프트맥스 함수 구현
            float maxLogit = logits.Max();
            float[] exps = logits.Select(logit => (float)Math.Exp(logit - maxLogit)).ToArray();
            float sumExps = exps.Sum();
            return exps.Select(exp => exp / sumExps).ToArray();
        }
        static void Main(string[] args)
        {
            // 모델 파일 경로 설정
            string modelPath = @"C:/Users/shhawork/Code/AI/RNN/book01/cnn_model.onnx";

            // ONNX 모델 불러오기
            using (var session = new InferenceSession(modelPath))
            {
                // 테스트할 이미지 파일 경로 설정
                string imagePath = @"C:/Temp/mnist/one.png";
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"{imagePath}이 경로에 이미지가 없습니다. ");
                    return;
                }

                // 이미지 로드 및 전처리
                var inputTensor = PreprocessImage(imagePath);

                // 모델 예측 수행
                var inputMeta = new NamedOnnxValue[] { NamedOnnxValue.CreateFromTensor("input", inputTensor) };
                using (var results = session.Run(inputMeta))
                {
                    // 결과 가져오기
                    var output = results.First().AsTensor<float>().ToArray();

                    // 소프트맥스 함수 적용
                    var probabilities = Softmax(output);

                    // 예측 결과 출력
                    Console.WriteLine("모델 예상값 (softmax를 이용한 분류) : ");
                    for (int i = 0; i < probabilities.Length; i++)
                    {
                        Console.WriteLine($"Class {i}: {probabilities[i]:P2}");
                    }

                    // 최종 예측 클래스 출력
                    int predictedClass = Array.IndexOf(probabilities, probabilities.Max());
                    Console.WriteLine($"\n손글씨는 예상값: {predictedClass}");
                }
            }
        }
    }
}
