"https://atcoder.jp/contests/abc058/tasks/abc058_b"
(defun flatten (l)
  (cond ((null l) nil)
        ((atom l) (list l))
        (t (loop for a in l appending (flatten a)))))
(defun solve (O E)
  (let* ((Esp (concatenate 'string E " "))
         (tmp (loop for i from 0 to (1- (length O))
                    collect (list (elt O i) (elt Esp i)))))
    (string-trim " " (format nil "~{~A~}" (flatten tmp)))))
(let* ((O (read-line))
       (E (read-line)))
  (format t "~a" (solve O E)))

(testing "test"
  (ok (equal (solve "xyz" "abc") "xaybzc"))
  (ok (equal (solve "atcoderbeginnercontest" "atcoderregularcontest")
         "aattccooddeerrbreeggiunlnaerrccoonntteesstt")))
