;;; https://atcoder.jp/contests/abc072/tasks/arc082_a
;;; no5, https://atcoder.jp/contests/abc072/submissions/1561080
(defun solve (n as)
  (let ((h (make-hash-table))
        (max 0))
    (mapc (lambda (x)
            (setf (gethash x h) (1+ (gethash x h 0)))
            (setf (gethash (1+ x) h) (1+ (gethash (1+ x) h 0)))
            (setf (gethash (1- x) h) (1+ (gethash (1- x) h 0))))
          as)
    (maphash (lambda (key value)
               (when (> value max) (setf max value)))
             h)
    max))
(let* ((n (read))
       (as (loop :repeat n :collect (read))))
  (format t "~a~%" (solve n as)))

(testing "test"
  (ok (equal 4 (solve 7 '(3 1 4 1 5 9 2))))
  (ok (equal 3 (solve 10 '(0 1 2 3 4 5 6 7 8 9))))
  (ok (equal 1 (solve 1 '(99999)))))
