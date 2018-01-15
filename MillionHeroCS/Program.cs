﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MillionHeroCS
{
    public static class Program
    {

        static void Main(string[] args)
        {
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("获取 OCR Token");
            var init_done = OCR.Init();
            if (init_done)
            {
                Console.WriteLine("获取 OCR Token 成功");
                Console.WriteLine("首次使用时按下 Ctrl + Q 并将鼠标放置于题目框左上角并悬停 500 毫秒");
                Console.WriteLine("随后将鼠标移动至题目框右下角并悬停 1 秒");
                Console.WriteLine("之后 Ctrl + Q 自动搜索答案");
                HotKeyManager.RegisterHotKey(Keys.Q, KeyModifiers.Control);
                HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(Engine.KeyPressed);
            }
            else
            {
                Console.WriteLine("获取 OCR Token 失败");
            }
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "exit")
                    return;
                Thread.Sleep(10);
            }
        }

    }
}
