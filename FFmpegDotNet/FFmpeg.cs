﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FFmpegDotNet
{
	public class FFmpeg
	{
		public static string Bin { get; set; } = Path.Combine("ffmpeg");
		public static string Probe { get; set; } = Path.Combine("ffprobe");

		public class Stream : Get
		{
			public Stream(string filePath) : base(filePath)
			{

			}
		}

		public class Process
		{
			internal string Print(string filePath)
			{
				var f = Path.Combine(Path.GetTempPath(), $"nemu_{new Random().Next(0, 999999999):D9}.xml");
				new Run().Execute($"\"{Probe}\" -print_format xml -show_format -show_streams \"{filePath}\" > \"{f}\"", Path.GetTempPath());
				return f;
			}
		}
	}
}