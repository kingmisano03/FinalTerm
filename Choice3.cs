using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("ใส่ที่อยู่ของไฟล์ข้อมูลภาพนำเข้า : ");
        string inputImagePath = Console.ReadLine();

        
        Console.Write("ใส่ที่อยู่ของไฟล์ข้อมูล Convolution Kernel : ");
        string kernelFilePath = Console.ReadLine();

       
        Console.Write("ใส่ที่อยู่ของไฟล์ข้อมูลภาพผลลัพธ์ : ");
        string outputImagePath = Console.ReadLine();

      
        double[,] inputImage = ReadImageDataFromFile(inputImagePath);

       
        double[,] kernel = ReadImageDataFromFile(kernelFilePath);

       
        int kernelSize = kernel.GetLength(0);
        int inputWidth = inputImage.GetLength(0);
        int inputHeight = inputImage.GetLength(1);
        int outputWidth = inputWidth - kernelSize + 1;
        int outputHeight = inputHeight - kernelSize + 1;
        double[,] outputImage = new double[outputWidth, outputHeight];

        for (int i = kernelSize / 2; i < inputWidth - kernelSize / 2; i++)
        {
            for (int j = kernelSize / 2; j < inputHeight - kernelSize / 2; j++)
            {
                double sum = 0.0;
                for (int k = -kernelSize / 2; k <= kernelSize / 2; k++)
                {
                    for (int l = -kernelSize / 2; l <= kernelSize / 2; l++)
                    {
                        sum += inputImage[i + k, j + l] * kernel[k + kernelSize / 2, l + kernelSize / 2];
                    }
                }
                outputImage[i - kernelSize / 2, j - kernelSize / 2] = sum;
            }
        }

        
        WriteImageDataToFile(outputImagePath, outputImage);

        Console.WriteLine("Convolution completed.");
    }

    static double[,] ReadImageDataFromFile(string filePath)
    {
        using (var streamReader = new StreamReader(filePath))
        {
            string[] sizeString = streamReader.ReadLine().Split();
            int width = int.Parse(sizeString[0]);
            int height = int.Parse(sizeString[1]);

            double[,] imageData = new double[width, height];

            for (int j = 0; j < height; j++)
            {
                string[] rowString = streamReader.ReadLine().Split();
                for (int i = 0; i < width; i++)
                {
                    imageData[i, j] = double.Parse(rowString[i]);
                }
            }

            return imageData;
       
