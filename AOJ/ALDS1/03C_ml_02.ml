(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/2411047/r6eve/OCaml *)
module DoublyLinkedList = struct
  type t = {
    mutable data : int;
    mutable next : t;
    mutable prev : t;
  }

  let make () =
    let rec head = { data = 0; next = head; prev = head } in
    head

  let insert data head =
    let x = { data = data; next = head.next; prev = head } in
    head.next.prev <- x;
    head.next <- x

  let delete x =
    x.next.prev <- x.prev;
    x.prev.next <- x.next

  let delete_first head = delete head.next

  let delete_last head = delete head.prev

  let delete_node data head =
    let rec doit ite =
      if ite == head then None
      else if ite.data = data then Some ite
      else doit ite.next in
    match doit head.next with
    | None -> ()
    | Some ite -> delete ite

  let iteri f head =
    let rec doit i ite =
      if ite == head then ()
      else begin
        f i ite.data;
        doit (i + 1) ite.next
      end in
    doit 0 head.next
end

module L = DoublyLinkedList

let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
      r := sub s (i + 1) (!j - i - 1) :: !r;
      j := i
    end
  done;
  sub s 0 !j :: !r

let () =
  let n = read_int () in
  let head = L.make () in
  for _ = 0 to n - 1 do
    match split_on_char ' ' (read_line ()) with
    | ["insert"; n] -> L.insert (int_of_string n) head
    | ["delete"; n] -> L.delete_node (int_of_string n) head
    | ["deleteFirst"] -> L.delete_first head
    | _ -> L.delete_last head
  done;
  L.iteri (fun i n -> if i <> 0 then print_string " "; print_int n) head;
  print_newline ()
