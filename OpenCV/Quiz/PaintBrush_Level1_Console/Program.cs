/*
Level1 
Menu 클래스를 확장하여 만들다 보니 의미가 커져 버렸습니다.
일단 하는 일이 많으니 PaintToolbox란 클래스 이름으로 정하고 수정하도록 하겠습니다.
*/

using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBrush_Level1_Console
{
    public static class IconFlags
    {
        public const int DRAW_RECTANGLE = 0;    // 사각형 그리기
        public const int DRAW_CIRCLE = 1;       // 원 그리기
        public const int DRAW_ECLIPSE = 2;      // 타원 그리기
        public const int DRAW_LINE = 3;         // 직선 그리기
        public const int DRAW_BRUSH = 4;        // 브러시 그리기
        public const int ERASE = 5;             // 지우개
        public const int OPEN = 6;              // 열기 명령
        public const int SAVE = 7;              // 저장 명령
        public const int PLUS = 8;              // 밝게 하기 명령
        public const int MINUS = 9;             // 어둡게 하기 명령
        public const int CLEAR = 10;            // 지우기 명령
        public const int COLOR = 11;            // 색상 아이콘
        public const int PALETTE = 12;          // 색상팔레트
        public const int HUE_IDX = 13;          // 색상인덱스
    }
    public class PaintToolbox
    {
        private int hue; // hue 값 - 전역변수 지정
        private List<Rect> icons = new List<Rect>();
        private Mat image;
        public List<Rect> Icons => icons;
        public Mat Image => image;


        public void SetImage(Mat img)
        {
            this.image = img;
        }

        public void PlaceIcons(Size size) // size : 아이콘 크기
        {
            List<string> iconNames = new List<string>
            {
                "rect", "circle", "eclipe", "line", "brush", "eraser",
                "open", "save", "plus", "minus", "clear", "color"
            };

            int btnRows = (int)Math.Ceiling(iconNames.Count / 2.0); // 2열 버튼의 행수

            
            for (int i = 0, k = 0; i < btnRows; i++)
            {
                for (int j = 0; j < 2; j++, k++)
                {
                    Point pt = new Point(j * size.Width, i * size.Height); // 각 아이콘 시작위치 
                    icons.Add(new Rect(pt, size)); // 각 아이콘 관심영역

                    Mat icon = Cv2.ImRead("image/icon/" + iconNames[k] + ".jpg", ImreadModes.Color);
                    if (icon.Empty()) continue; // 예외처리

                    Cv2.Resize(icon, icon, size); // 아이콘 영상 크기 통일
                    icon.CopyTo(image[icons[k]]);
                }
            }

        }

        public void CreateHueIndex(Rect rect) // rect - 색상인덱스 영역
        {
            Mat mHueIdx = image.SubMat(rect); // 색상인덱스 영역 참조
            float ratio = 180.0f / rect.Height; // 색상인덱스 세로크기의 hue 스케일

            for (int i = 0; i < rect.Height; i++)
            {
                Scalar hueColor = new Scalar(i * ratio, 255, 255); // HSV 색상 지정
                mHueIdx.Row(i).SetTo(hueColor); // 한 행의 색상 지정
            }
            Cv2.CvtColor(mHueIdx, mHueIdx, ColorConversionCodes.HSV2BGR); // HSV에서 RGB로 변환
        }

        public void CreatePalette(int posY, Rect rectPale) // pos_y : 마우스 클릭 y 좌표, rect_pale: 팔레트 영역
        {
            Mat mPalette = image.SubMat(rectPale); // 팔레트 영역 참조
            float ratio1 = 180.0f / rectPale.Height; // 팔레트 높이에 따른 hue 비율
            float ratio2 = 256.0f / rectPale.Width; // 팔레트 너비에 따른 saturation 비율 
            float ratio3 = 256.0f / rectPale.Height; // 팔레트 높이에 따른 intensity 비율

            hue = (int)Math.Round((posY - rectPale.Y) * ratio1); // 색상팔레트 기본 색상

            for (int i = 0; i < mPalette.Rows; i++)
            {
                for (int j = 0; j < mPalette.Cols; j++)
                {
                    int saturation = (int)Math.Round(j * ratio2); // 채도 계산
                    int intensity = (int)Math.Round((mPalette.Rows - i - 1) * ratio3); // 명도 계산
                    mPalette.At<Vec3b>(i, j) = new Vec3b((byte)hue, (byte)saturation, (byte)intensity); // HSV 색상 지정
                }
            }
            Cv2.CvtColor(mPalette, mPalette, ColorConversionCodes.HSV2BGR); // HSV에서 RGB로 변환
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat(500, 800, MatType.CV_8UC3, Scalar.All(255)); // Create the Mat object in Main
            PaintToolbox toolbox = new PaintToolbox();

            toolbox.SetImage(image);
            toolbox.PlaceIcons(new Size(60, 60)); // 아이콘 배치, 아이콘 크기

            Rect lastIcon = toolbox.Icons.Last(); // 아이콘 사각형 마지막 원소
            //Point startPale = lastIcon.BottomRight + new Point(0, 5); // 팔레트 시작위치
            Point startPale = new Point(0, lastIcon.BottomRight.Y + 5); //팔레트 시작위치

            toolbox.Icons.Add(new Rect(startPale, new Size(100, 100))); // 팔레트 사각형 추가
            toolbox.Icons.Add(new Rect(startPale + new Point(105, 0), new Size(15, 100))); // 색상인덱스 사각형 추가

            toolbox.CreateHueIndex(toolbox.Icons[IconFlags.HUE_IDX]); // 팔레트 생성
            toolbox.CreatePalette(startPale.Y, toolbox.Icons[IconFlags.PALETTE]); // 색상인덱스 생성

            Cv2.ImShow("image", toolbox.Image);
            Cv2.WaitKey();
        }
    }
}
