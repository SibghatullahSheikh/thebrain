using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VDG
{
    namespace TheBrain
    {
        public class Brain
        {

            public class DiffInfo
            {
                public string Value;
                public bool IsAdded;
                public bool SameLength;
                public int StartIndex;
                public int Length;

                public DiffInfo(string value, bool isadded, int index, int len, bool samelen = false)
                {
                    Value = value;
                    IsAdded = isadded;
                    StartIndex = index;
                    Length = len;
                    SameLength = samelen;
                }
            }

            public static DiffInfo GetChange(string A, string B)
            {
                if (B.Length == 0)
                {
                    return new DiffInfo(A, false, 0, A.Length);
                }
                if (A.Length == 0)
                {
                    return new DiffInfo(B, true, 0, B.Length);
                }
                int i, g, remi, remg;
                i = g = 0;
                while (i + 1 < A.Length && g + 1 < B.Length && A[++i] == B[++g]) ;
                remi = i;
                remg = g;
                if (A.Length > B.Length)
                {
                    while (i + 1 < A.Length && g < B.Length && A[++i] != B[g]) ;
                    return new DiffInfo(A.Substring(remi + 1, i - remi), false, remi + 1, i - remi);
                }
                else if (A.Length < B.Length)
                {
                    while (i < A.Length && g + 1 < B.Length && A[i] != B[++g]) ;
                    return new DiffInfo(B.Substring(remg + 1, g - remg), true, remg + 1, g - remg);
                }
                else
                {
                    while (i < A.Length && g + 1 < B.Length && A[i] != B[++g]) ;
                    return new DiffInfo(B.Substring(remg + 1, g - remg), true, remg + 1, g - remg, true);
                }
                throw new Exception("Dont know what happened");
            }

            public string diff(string a1, string a2){
	            var matrix = new int[a1.Length+1][];
                int y = 0, x = 0;
	            for(y=0; y<matrix.Length; y++){
		            matrix[y] = new int[a2.Length+1];
		
		            for(x=0; x<matrix[y].Length; x++){
			            matrix[y][x] = 0;
		            }
	            }
	
	            for(y=1; y<matrix.Length; y++){
		            for(x=1; x<matrix[y].Length; x++){
			            if(a1[y-1]==a2[x-1]){
				            matrix[y][x] = 1 + matrix[y-1][x-1];
			            } else {
				            matrix[y][x] = Math.Max(matrix[y-1][x], matrix[y][x-1]);
			            }
		            }
	            }
                return getDiff(matrix, a1, a2, x-1, y-1);
            }
            bool appendbool1 = true, appendbool2 = true;
            public string getDiff(int[][] matrix, string a1, string a2, int x, int y){
                string ret = "";
                
	            if(x>0 && y>0 && a1[y-1]==a2[x-1]){
                    
                    ret += getDiff(matrix, a1, a2, x - 1, y - 1);
                    if (!appendbool1 || !appendbool2) ret += "\x1";
		            ret += a1[y-1];
                    appendbool1 = appendbool2 = true;
	            } else {
		            if(x>0 && (y==0 || matrix[y][x-1] >= matrix[y-1][x])){
                        ret += getDiff(matrix, a1, a2, x - 1, y);
                        if (appendbool1) ret += "\x2";
                        appendbool1 = false;
                        ret += "" + a1[y - 1];

		            } else if(y>0 && (x==0 || matrix[y][x-1] < matrix[y-1][x])){
                        ret += getDiff(matrix, a1, a2, x, y - 1);
                        if (appendbool2) ret += "\x1";
                        appendbool2 = false;
                        ret += "" + a2[y - 1];
		            } else {
			            return null;
		            }
	            }
                return ret;
            }

            public string GetPatterns(string input)
            {
                string[] splitted = input.Split('\x1');
                string ret = "";
                foreach (string spl in splitted)
                {
                    if(spl.Contains('\x2')){
                        string[] elems = spl.Split('\x2');
                        if (!Regex.IsMatch(elems[0], "[^0-9]") && !Regex.IsMatch(elems[1], "[^0-9]")) ret += "([0-9]+)" + "\r\n";
                        else if (!Regex.IsMatch(elems[0], "[^ A-z0-9]") && !Regex.IsMatch(elems[1], "[^ A-z0-9]")) ret += "([ A-z0-9]+)" + "\r\n";
                        else ret += "([\\d\\D]+)" + "\r\n";
                    } else ret += spl + "\r\n";
                    
                }
                return ret;
            }

            public string[] GetCommonSequences(List<string> strings)
            {
                List<DiffInfo> diffs = new List<DiffInfo>();
                string Base = strings[0];
                foreach (string str in strings)
                {
                    diffs.Add(GetChange(Base, str));
                }
                foreach (DiffInfo diff in diffs)
                {
                    Console.WriteLine(diff.Value);
                }
                return null;

            }

        }
    }
}
