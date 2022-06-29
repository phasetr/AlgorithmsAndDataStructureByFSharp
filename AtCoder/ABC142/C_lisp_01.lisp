;; https://atcoder.jp/contests/abc142/tasks/abc142_c
(defun solve (n xs)
  (format nil "~{~A~^ ~}"
          (mapcar (lambda (x) (car x))
                  (sort
                   (apply #'mapcar #'list
                          (list (loop for i below n collect (1+ i))
                                xs))
                   (lambda (x y) (< (cadr x) (cadr y)))))))
(princ
 (let* ((n (read))
        (xs (loop :repeat n :collect (read))))
   (solve n xs)))

(testing "chk"
  (ok (equal (solve 3 '(2 3 1)) "3 1 2"))
  (ok (equal (solve 5 '(1 2 3 4 5)) "1 2 3 4 5"))
  (ok (equal (solve 8 '(8 2 7 3 4 5 6 1))
             "8 2 4 5 6 7 3 1")))
