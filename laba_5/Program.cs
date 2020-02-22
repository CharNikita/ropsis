using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Matrix_MultBencmark
{
   [RankColumn, MinColumn, MeanColumn, MaxColumn, MedianColumn]
   public class TestClass
   {
      const int N_MAX = 700;

      int[,] A  = new int[N_MAX, N_MAX];
      int[,] B  = new int[N_MAX, N_MAX];
      int[,] C  = new int[N_MAX, N_MAX];
      int[,] Bt = new int[N_MAX, N_MAX];

      [Params(500, 550, 600, 650, 700)]
      public int N;


      [GlobalSetup]
      public void Setup()
      {
         Random rnd = new Random();
         for (int i = 0; i < N_MAX; i++)
            for (int j = 0; j < N_MAX; j++)
            {
               A[i, j] = rnd.Next(10);
               B[i, j] = rnd.Next(10);
               Bt[i, j] = B[j, i];
            }
      }

      [Benchmark]
      public void WithoutTranspose()
      {
         for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
               C[i, j] = 0;
               for (int k = 0; k < N; k++)
                  C[i, j] += A[i, k] * B[k, j];
            }
      }

      [Benchmark]
      public void WithTranspose()
      {
         for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
               C[i, j] = 0;
               for (int k = 0; k < N; k++)
                  C[i, j] += A[i, k] * Bt[j, k];
            }
      }

      class Program
      {
         public static void Main(string[] args)
         {
            var summary = BenchmarkRunner.Run<TestClass>();
            Console.ReadKey();
         }
      }
   }
}