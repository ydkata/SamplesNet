<Query Kind="Program" />

  class 商品情報
  {
    public int Id;
    public string 名前;
  }

  class 商品販売価格
  {
    public int Id;
    public int 価格;
    public string 店名;
  }

  static void Main(string[] args)
  {
    商品情報[] 商品情報データ =
    {
      new 商品情報() { Id = 1, 名前="PC-8001" },
      new 商品情報() { Id = 2, 名前="MZ-80K" },
      new 商品情報() { Id = 3, 名前="Basic Master Level-3" },
    };

    商品販売価格[] 商品販売価格データ =
    {
      new 商品販売価格() {Id=1, 価格=168000, 店名="BitOut"},
      new 商品販売価格() {Id=1, 価格=148000, 店名="富士山音響"},
      new 商品販売価格() {Id=2, 価格=178000, 店名="富士山音響"},
      new 商品販売価格() {Id=3, 価格=298000, 店名="マイコンセンターROM"},
      new 商品販売価格() {Id=3, 価格=229000, 店名="富士山音響"},
    };

	// Queryを作る.（この時点では検索されていない）
    var query = from x in 商品情報データ
                join y in 商品販売価格データ
                                  on x.Id equals y.Id into z
				where 商品販売価格データ.店名 == "ROM"
                select new { Name = x.名前, 商品データ = z };
	// Where条件を追加する
	// query.Where(y => y.店名.Contains("ROM"));

	// Qyeryの結果を表示する。
    foreach (var 商品 in query)
    {
      Console.WriteLine("{0}", 商品.Name);

      foreach (var 価格情報 in 商品.商品データ)
      {
        Console.WriteLine("\t{0} {1:C}",
                                価格情報.店名, 価格情報.価格);
      }
    }
  }