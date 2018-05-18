<Query Kind="Program" />

class 商品情報
{
	public int Id;
	public string Name;
}

class 商品販売価格
{
	public int ProdId;
	public int Price;
	public string ShopName;
}

void Main()
{
	Console.WriteLine("Execute Test1.----------");
	this.Test1();
	
	Console.WriteLine("Execute Test2.----------");
	this.Test2();

	Console.WriteLine("Execute Test3.----------");
	this.Test3();
}

// Define other methods and classes here
private void Test1() {
	 String[] words = {"a", "bb", "cc", "dd"};
	 
	// Query式
	 IEnumerable<String>  shortWords = from word in words where word.Length < 2 select word;
	 foreach (String w in shortWords) {
	 	Console.WriteLine(w);
	 }
	
	// Lamda式 Parameter => 戻り値
	IEnumerable<String>  shortQuery = words.Where(p => p.Length > 1);
	shortQuery = shortQuery.Where(p => p.Contains("c"));	// Add "AND"Condition
	shortQuery = shortQuery.Select(p =>  "【" + p.ToString() + "】");	// Add "AND"Condition	
	
	 foreach (String w in shortQuery) {
	 	Console.WriteLine(w);
	 }
}

class Department {
	public int DepartmentId { get; set; }
	public string Name { get; set; }
}

private void Test2() {
	List<Department> departments = new List<Department>(){
 									 	 new Department{ DepartmentId = 1, Name = "Account" }
										,new Department{ DepartmentId = 2, Name = "Sales" }
										,new Department{ DepartmentId = 3, Name = "Marketing" }
									};
									
	var departmentsList = departments.Where(p => p.Name.Contains("a")).Select(p => new Department{ DepartmentId = p.DepartmentId + 100, Name = "[" + p.Name + "]" } );
	// when add multiple select, but use last select query. 
	departmentsList = departments.Select(p => new Department{ DepartmentId = p.DepartmentId + 200, Name = "2[" + p.Name + "]" } );
	departmentsList = departments.Select(p => new Department{ DepartmentId = p.DepartmentId + 300, Name = "3[" + p.Name + "]" } );
	
   foreach (var dept in departmentsList)
   {
      Console.WriteLine("Department Id = {0} , Department Name = {1}",dept.DepartmentId, dept.Name);
   }
}

// Joinのテスト
private void Test3() {
    商品情報[] 商品情報データ =
    {
      new 商品情報() { Id = 1, Name="PC-8001" },
      new 商品情報() { Id = 2, Name="MZ-80K" },
      new 商品情報() { Id = 3, Name="Basic Master Level-3" },
    };

    商品販売価格[] 商品販売価格データ =
    {
      new 商品販売価格() {ProdId=1, Price=168000, ShopName="BitOut"},
      new 商品販売価格() {ProdId=1, Price=148000, ShopName="富士山音響"},
      new 商品販売価格() {ProdId=2, Price=178000, ShopName="富士山音響"},
      new 商品販売価格() {ProdId=3, Price=298000, ShopName="マイコンセンターROM"},
      new 商品販売価格() {ProdId=3, Price=229000, ShopName="富士山音響"},
    };
	
	// SELECT * FROM 商品情報データ as A INNER JOIN 商品販売価格データ as B ON A.ID = B.ID 
	var qRes = 商品情報データ.Join(
								商品販売価格データ,				   // Iner Table
								I => I.Id,			 			// OuterKeySelector
								P => P.ProdId,				 	// InerKey Selector
								(I,P) => new{ ProdInfo = I, PriceInfo = P}		// resultSelector
						// JoinしたのでSelect句はここで定義しないとおかしくなると想定
						).Select(a => new{ Id = a.ProdInfo.Id, Name = a.ProdInfo.Name, Price = a.PriceInfo.Price, Shop = a.PriceInfo.ShopName } );

   foreach (var prod in qRes)
   {
      Console.WriteLine("Department Id = {0} , Department Name = {1} , Price = {2}",prod.Id, prod.Name, prod.Price);
   }

	
	// 追加で絞込み
	Console.WriteLine("絞り込みする");
	var qRes2 = qRes.Where(n => n.Price >= 200000);
	foreach (var prod in qRes2)
	{
		Console.WriteLine("Department Id = {0} , Department Name = {1} , Price = {2}",prod.Id, prod.Name, prod.Price);
	}
}