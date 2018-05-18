<Query Kind="Program" />

// Define other methods and classes here

///
/// LINQの基本のための理解
///
void Main()
{
	// 理解その1 ラムダ式の書き方
	List<string> list = new List<string>();
	string s = "hoge";
	list.Add(s);
	list.Select(Append);									// Methodを指定するが、実行はされない。
	IEnumerable<string> res = list.Select(Append);			// 当然Methodも定義できるその場合は別変数代入で実行される。
	res = res.Select((string p) => {						// Directに書くことも可能。短い場合はMethodを定義するよりこの方がよい。
									Console.WriteLine(String.Format("#Log2 Append = {0}", p));
									return p + ".txt";
									});
	Console.WriteLine(res);
	
	Console.WriteLine("*****************************************************");
	
	// 理解2 ラムダ式を使う
	// 関数を作った場合
	List<string> lsTes = new List<string>(){"a", "b", "c", "d"};
	Console.WriteLine(String.Format("#Log4 {0}", lsTes.Count));
	var newList = TestR(lsTes, (string q) => { return q + "xxxxx";});
	foreach (string v in newList) {
		Console.WriteLine(String.Format("#Log6 v = {0}", v));
	}

	Console.WriteLine("*****************************************************");

	/// LINQの拡張メソッド
	/// 拡張Methodを作った場合
	List<string> lsTes2 = new List<string>(){"a1", "b2", "c1", "d3"};
	var lsRes = lsTes2.Where( p => p.Contains("1") == true).Trace();   // "a1" "c1" が抽出される
	foreach (string v in lsRes) {
		Console.WriteLine(String.Format("#Log8 v = {0}", v));
	}	
	
}

/// 理解その１ ラムダ式
private static string Append(string s)
{
	Console.WriteLine(String.Format("#Log1 Append = {0}", s));
    return s + ".txt";
}

/// 理解2 ラムダ式
/// 関数を作ってみる
private static IEnumerable<string> TestR(List<string> list, Func<string, string> fx)
{
	var result = new List<string>();
	foreach (string v in list) {
		result.Add(fx(v));
		Console.WriteLine(String.Format("#Log5 v = {0}", v));
	}
	return result;
}

/// 拡張Methodの定義. 
/// Static ClassにStatic Methodを作る必要がある。
public static class SampleExtension
{
	/// 拡張Methodを定義してみる
	/// 拡張メソッドは、そのクラス自体には全く手を付けることなく、しかし、そのクラスにあたかもインスタンスメソッドが追加されたかのように見せかける。
	/// Function Methodも指定できる
	public static IEnumerable<T> Trace<T>(this IEnumerable<T> source)
	{
		foreach (T v in source) {
			Console.WriteLine(String.Format("#Log7 v = {0}", v));
			yield return v;
		}
	}
}