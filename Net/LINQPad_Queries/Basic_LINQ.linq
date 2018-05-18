<Query Kind="Program" />

// Define other methods and classes here

///
/// LINQの基本
///
void Main()
{
	List<string> list = new List<string>();
	string s = "hoge";
	list.Add(s);
	list.Select(Append);									// 何も発生しない
	IEnumerable<string> res = list.Select(Append);			// 当然Methodも定義できるその場合は別変数代入で実行される。
	res = res.Select((string p) => {						// Directに書くことも可能。短い場合はこの方がよい。
															Console.WriteLine(String.Format("#Log2 Append = {0}", p));
															return p + ".txt";
												});
	Console.WriteLine(res);
	
	List<string> lsTes = new List<string>(){"a", "b", "c", "d"};
	Console.WriteLine(String.Format("#Log4 {0}", lsTes.Count));
	var newList = TestR(lsTes, (string q) => { return q + "xxxxx";});
	foreach (string v in newList) {
		Console.WriteLine(String.Format("#Log6 v = {0}", v));
	}
	
}

private static string Append(string s)
{
	Console.WriteLine(String.Format("#Log1 Append = {0}", s));
    return s + ".txt";
}

/// /////////////////////
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

