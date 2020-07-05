#!/bin/bash
chmod +x 2A02.hs
cat << EOS
RESULT
1 2 3 4 5
8
======
EOS
./2A02.hs << EOS
5
5 3 2 4 1
EOS

echo "======"

cat << EOS
RESULT
1 2 3 4 5 6
9
======
EOS
./2A02.hs << EOS
6
5 2 4 6 1 3
EOS
