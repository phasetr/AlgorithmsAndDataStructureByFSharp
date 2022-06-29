#|
https://atcoder.jp/contests/abc096/submissions/22914132
|#
(defun solve (h w s)
  (let ((ans "Yes"))
    (loop for i from 1 below h do
      (loop for j from 1 below w do
        (if (char= (aref s i j) #\#)
            (when (and (char= (aref s (- i 1) j) #\.)
                       (char= (aref s (+ i 1) j) #\.)
                       (char= (aref s i (- j 1)) #\.)
                       (char= (aref s i (+ j 1)) #\.))
              (setq ans "No")))))
    ans))
(let* ((h (read))
       (w (read))
       ;; 両端に`.`を追加して「1-h」「1-w」をチェックする.
       (s (make-array (list (+ h 2) (+ w 2)) :initial-element #\.)))
  ;; 絵の文字列データ取得
  (loop for i below h do
    (let ((a (read-line)))
      (loop for j below w do
        (setf (aref s (1+ i) (1+ j)) (char a j)))))

  (format t "~A~%" (solve h w s)))
