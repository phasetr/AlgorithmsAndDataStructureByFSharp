// https://gist.github.com/taiseiKMC/c422618cca920bd1a8a5bcde54a7a802
type 'a SegmentTree =
  val private op : 'a -> 'a -> 'a
  val private e : 'a
  val private node : array<'a>
  val private leafCount : int
  new (ary:array<'a>, _op, _e) as this =
    let lc = SegmentTree<'a>.LeastSquare ary.Length
    {
      op = _op
      e = _e
      leafCount = lc
      node = Array.create (lc*2) _e
    }
    then
    for i=0 to ary.Length-1 do
      this.node.[i+lc-1] <- ary.[i]
    done;
    this.Init()

  static member private LeastSquare k =
    if k=0 then 0 else
    let rec loop i t =
      if i>=64 then t else
      loop (i*2) (t ||| (t>>>i))
    loop 1 (k-1) + 1

  static member private ChildLeft k = k*2+1
  static member private ChildRight k = k*2+2
  static member private Parent k = (k-1)/2

  member private this.Init () =
    let rec init k =
      if k >= this.leafCount-1 then this.node.[k]
      else
        this.node.[k] <- this.op (init <| SegmentTree<'a>.ChildLeft k) (init <| SegmentTree<'a>.ChildRight k)
        this.node.[k]
    init 0 |> ignore

  member this.Fold a b =
    let rec fold k l r =
      if r<=a || b<=l then this.e
      else if a<=l && r<= b then this.node.[k]
      else this.op (fold (SegmentTree<'a>.ChildLeft k) l ((l+r)/2))
             (fold (SegmentTree<'a>.ChildRight k) ((l+r)/2) r)
    fold 0 0 this.leafCount

  member this.Update k x =
    let t = k + this.leafCount - 1
    this.node.[t] <- x
    let rec loop t =
      if t<=0 then ()
      else
        let t = SegmentTree<'a>.Parent t
        this.node.[t] <- this.op this.node.[SegmentTree<'a>.ChildLeft t]
                    this.node.[SegmentTree<'a>.ChildRight t]
        loop t
    loop t
