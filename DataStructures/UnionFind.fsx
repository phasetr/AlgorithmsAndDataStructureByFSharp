@"cf. https://atcoder.jp/contests/abc157/submissions/10481595"
type UnionFind =
  /// par 添字iが属するグループID (0-indexed)
  /// size 各集合の要素数
  { par: int array; size: int array }

  /// xの先祖(xが属するグループID)
  member self.Root (x: int) =
    let par = self.par
    let rec loop x =
      if x = par.[x] then x
      else let px = par.[x] in par.[x] <- loop px; par.[x]
    loop x

  /// 連結判定
  /// ならし O(α(n))
  member self.Find(x: int, y: int) = self.Root(x) = self.Root(y)

  /// xとyを同じグループに併合
  /// ならし O(α(n))
  member self.Unite(x: int, y: int): bool =
    let par, size = self.par, self.size
    let rx, ry = self.Root(x), self.Root(y)
    if rx = ry then false // 既に同じグループ
    else
      // 経路圧縮
      let large, small = if size.[rx] < size.[ry] then ry, rx else rx, ry
      par.[small] <- large
      size.[large] <- size.[large] + size.[small]
      size.[small] <- 0
      true

  /// xが属する素集合の要素数, O(1)
  member self.Size(x: int): int = let rx = self.Root(x) in self.size.[rx]

  /// 連結成分の個数, O(n)
  member self.TreeNum: int =
    ((0,0), self.par) ||> Array.fold (fun (i,cnt) x -> (i+1, cnt + if i=x then 1 else 0)) |> snd

@"破壊的なUnion-Findの簡易実装
cf. ../AtCoder/ABC157/D_fs_00_02.fsx"
module UnionFind1 =
  type UnionFind = { par: int[]; size: int[]}
  let N = 100 // 値は適当に修正
  let uf = { par = Array.init N id; size = Array.create N 1 }

  let rec root x =
    if uf.par.[x] = x then x
    else let r = root uf.par.[x] in uf.par.[x] <- r; r
  let find x y = root x = root y
  let unite x y =
    let rx,ry = root x, root y
    if rx=ry then false
    else
      let large,small = if uf.size.[rx]<uf.size.[ry] then ry,rx else rx,ry
      uf.par.[small] <- large
      uf.size.[large] <- uf.size.[large]+uf.size.[small]
      uf.size.[small] <- 0
      true
  let size x = let rx = root x in uf.size.[rx]
