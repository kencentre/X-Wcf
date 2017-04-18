using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks; 
using System.Drawing;
using System.Drawing.Imaging;
namespace E_Common
{ 
    public class ImageHandler
    {   
        /// <summary>
        /// 图片切割(按最短边切割正方向区域)
        /// </summary>
        /// <param name="sourceFile">目标源文件</param>
        /// <param name="quality">压缩比</param>
        /// <param name="outputFile">输出目录</param>
        /// <returns></returns>
        public static bool imageCut(string sourceFile, long quality, String outputFile)
        { 
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float side = 0;
                float xaxis = 0;
                float yaxis=0;
                if (sourceImage.Height > sourceImage.Width)
                {
                    side = (float)sourceImage.Width;
                    yaxis = (sourceImage.Height - sourceImage.Width) / 2 ;
                }
                else
                {
                    side = (float)sourceImage.Height;
                    xaxis = (sourceImage.Width - sourceImage.Height) / 2 ;
                }
                String outputImage = "";
                RectangleF cloneRect = new RectangleF(xaxis, yaxis, side, side);
                Bitmap newImage = sourceImage.Clone(cloneRect, PixelFormat.Format24bppRgb);
                outputImage = outputFile + xaxis + yaxis + ".jpg";
                newImage.Save(outputImage, myImageCodecInfo, myEncoderParameters);
               
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region imageCut
        /// 图片切割函数
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="xNum">在Ｘ轴上的切割数量</param>
        /// <param name="yNum">在Ｙ轴上的切割数量</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="outputFile">输出文件名，不带后缀</param>
        /// <returns>成功返回true，失败则返回false</returns>
        public static bool imageCut(String sourceFile, int xNum, int yNum, long quality, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width / xNum;
                float yWidth = sourceImage.Height / yNum;
                String outputImage = "";

                for (int countY = 0; countY < yNum; countY++)
                    for (int countX = 0; countX < xNum; countX++)
                    {

                        RectangleF cloneRect = new RectangleF(countX * xWidth, countY * yWidth, xWidth, yWidth);
                        Bitmap newImage = sourceImage.Clone(cloneRect, PixelFormat.Format24bppRgb);
                        outputImage = outputFile + countX + countY + ".jpg";
                        newImage.Save(outputImage, myImageCodecInfo, myEncoderParameters);

                    }
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region imageCompress

        /// <summary>
        /// 图片压缩函数
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="ouputFile">输出文件名,请用 .jpg 后缀 </param>
        /// <returns>成功返回true，失败则返回false</returns>
        public static bool imageCompress(String sourceFile, long quality, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;

                sourceImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;

            }
            catch
            {
                return false;
            }

        }
        #endregion imageCompress

        #region getThumImage
        /**/
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="multiple">收缩倍数</param>
        /// <param name="outputFile">输出文件名</param>
        /// <returns>成功返回true,失败则返回false</returns>
        public static bool getThumImage(String sourceFile, long quality, int multiple, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion getThumImage

        #region ImageCodecInfo
        /// <summary>
        /// 获取图片编码信息
        /// </summary>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion
    }
} 