using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Text;
public interface I{IEnumerable<string>R(int s);int L{get;}}
public class T:I{string m;public T(string x){m=x;}public IEnumerable<string>R(int s){return new[]{m};}public int L{get{return m.Length;}}}
public class B:I{IEnumerable<I> a;
public B(IEnumerable<I>b){a=b;}
public static void Main(){var r=Console.In;int i=int.Parse(r.ReadLine());Console.Out.WriteLine(O(i,r));}
public static I O(int n,TextReader r){var a=new List<I>();for(int i=0;i<n;i++){var l=r.ReadLine();int c;a.Add(int.TryParse(l,out c)?O(c, r):new T(l));}return new B(a);}
public int L{get{return a.Max(x=>x.L)+4;}}
public IEnumerable<string> R(int s){int i=s-4;var r=new List<string>();foreach(I b in a){r.AddRange(b.R(i));}yield return H(s,'.');foreach(var e in r){var line=new StringBuilder("| "+e+" ");line.Append(' ',i-e.Length);yield return line+"|";}yield return H(s,'\'');}
string H(int m,char c){var l=new StringBuilder();l.Append(c);l.Append('-',m-2);l.Append(c);return l.ToString();}
public override string ToString(){return string.Join("\r\n",R(L));}}