#!/bin/bash
chmod +x 2B01.hs
cat << EOS
RESULT
1 2 3 4 5 6
4
======
EOS
./2B01.hs << EOS
6
5 6 4 2 1 3
EOS

echo "======"

cat << EOS
RESULT
1 2 3 4 5 6
3
======
EOS
./2A01.hs << EOS
6
5 2 4 6 1 3
EOS
