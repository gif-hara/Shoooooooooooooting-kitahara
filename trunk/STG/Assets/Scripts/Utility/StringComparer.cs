//================================================
/*!
    @file   StringComparer.cs

    @brief  文字列を数値を考慮してソートする.
                 http://www.shise.net/wiki/wiki.cgi?page=C%23%2F%BF%F4%C3%CD%A4%F2%B9%CD%CE%B8%A4%B7%A4%C6%CA%C2%A4%D9%C2%D8%A4%A8%A4%EBIComparer.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;


public class StringComparer : IComparer
{
    public static bool NumCheck = true;

    private static string _numRegex = @"^(.*?)([0-9]+).*?$";
    private static Regex regex = new Regex(_numRegex);

    //xがyより小さいときはマイナスの数、大きいときはプラスの数、
    //同じときは0を返す
    public int Compare(object x, object y)
    {
        string a = Convert.ToString(x);
        string b = Convert.ToString(y);

        string aorg = a;
        string borg = b;

        // 何もしなくても等しかったら０
        if (a == b)
        {
            return 0;
        }

        // 数字部分切り出し保存用
        int? ai = null;
        int? bi = null;

        // 数字チェックするなら
        if (NumCheck)
        {
            // 正規表現で切り出す
            Match matchCol = regex.Match(a);

            // マッチしたら
            if (matchCol.Success)
            {
                // 数字の前までの文字列と
                a = matchCol.Groups[1].Value;
                // 数字に分ける
                ai = Convert.ToInt32(matchCol.Groups[2].Value);
            }

            // 正規表現
            matchCol = regex.Match(b);
            // マッチ
            if (matchCol.Success)
            {
                // 文字列
                b = matchCol.Groups[1].Value;
                // 数字
                bi = Convert.ToInt32(matchCol.Groups[2].Value);
            }
        }

        // 文字列の比較
        int t = string.Compare(a, b);

        // 等しければ
        if (NumCheck && t == 0)
        {
            // 
            if (ai == null && bi != null)
            {
                t = -1;
            }
            else if (ai != null && bi == null)
            {
                t = 1;
            }
            else if (ai == null && bi == null)
            {
                t = string.Compare(aorg, borg);
            }
            else
            {
                t = (int)(ai - bi);
                if (t == 0)
                {
                    t = string.Compare(aorg, borg);
                }
            }
        }

        return t;
    }
}
