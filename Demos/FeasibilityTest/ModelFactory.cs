﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeasibilityTest
{
    class ModelFactory
    {
        private static char[] separator = new char[] { ' ', 'X', 'Y', 'Z' };

        public static List<vec3> OpenFile(string filename)
        {
            List<vec3> pointList = new List<vec3>();
            vec3 lastPoint = new vec3();
            using (var stream = new StreamReader(filename))
            {
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1)
                    {
                        var point = new vec3(float.Parse(parts[0]), lastPoint.y, lastPoint.z);
                        pointList.Add(point);
                        lastPoint = point;
                    }
                    else if (parts.Length == 2)
                    {
                        var point = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), lastPoint.z);
                        pointList.Add(point);
                        lastPoint = point;
                    }
                    else if (parts.Length == 3)
                    {
                        var point = new vec3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
                        pointList.Add(point);
                        lastPoint = point;
                    }
                    else
                    { throw new NotImplementedException(); }
                }
            }

            return pointList;
        }
    }
}
