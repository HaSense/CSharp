using ImageEnhencedWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using System.Diagnostics;

namespace ImageEnhencedWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadSucess()
        {
            return View();
        }

        // 이미지 업로드를 처리하는 액션 메서드
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            // 이미지 파일이 있는지 확인
            if (imageFile != null && imageFile.Length > 0)
            {
                // 저장할 경로 지정 (wwwroot/images 폴더에 저장)
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // 디렉토리가 존재하지 않으면 생성
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // 파일명을 고유하게 지정 (GUID 사용)
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                // 파일을 서버에 저장
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // OpenCVSharp을 사용하여 이미지를 불러옴
                Mat img = Cv2.ImRead(filePath);

                // 히스토그램 평활화를 적용할 새로운 이미지 경로
                var enhancedFileName = "enhanced_" + fileName;
                var enhancedFilePath = Path.Combine(uploadPath, enhancedFileName);

                try
                {
                    // 히스토그램 평활화 적용
                    Mat equalizedImg = new Mat();
                    Cv2.CvtColor(img, equalizedImg, ColorConversionCodes.BGR2GRAY); // 흑백 변환
                    Cv2.EqualizeHist(equalizedImg, equalizedImg); // 히스토그램 평활화

                    // 평활화된 이미지를 저장
                    Cv2.ImWrite(enhancedFilePath, equalizedImg);

                    // 파일 생성 여부 확인
                    if (!System.IO.File.Exists(enhancedFilePath))
                    {
                        throw new Exception("Enhanced image file not created.");
                    }
                }
                catch (Exception ex)
                {
                    // 오류 발생 시 로그 출력 또는 예외 처리
                    Console.WriteLine("Error while processing image: " + ex.Message);
                    return View("UploadFailed");
                }

                // 원본 이미지와 평활화된 이미지 경로를 View로 전달
                ViewBag.OriginalImagePath = "/images/" + fileName;
                ViewBag.EnhancedImagePath = "/images/" + enhancedFileName;
               
                return View("UploadSuccess");
            }

            // 업로드 실패 시 처리
            return View("UploadFailed");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
