"https://atcoder.jp/contests/abc059/tasks/abc059_b
問題文
2 つの正整数 A,B が与えられるので、その大小を比較してください。

制約
1≦A,B≦10^{100}

入力の A,B の先頭は0でない。"

(defun solve (A B)
  (cond ((< A B) "LESS")
        ((< B A) "GREATER")
        (t "EQUAL")))
(let* ((A (read))
       (B (read)))
  (format t "~a" (solve A B)))

(testing "test"
  (ok (equal (solve "36" "24") "GREATER"))
  (ok (equal (solve "850" "3777") "LESS"))
  (ok (equal (solve "9720246" "22516266") "LESS"))
  (ok (equal (solve "123456789012345678901234567890" "234567890123456789012345678901") "LESS")))
