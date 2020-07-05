#!/bin/bash
chmod +x 1D01.hs
cat << EOS
RESULT 3
======
EOS
./1D01.hs << EOS
6
5
3
1
3
4
3
EOS

echo "======"

cat << EOS
RESULT -1
======
EOS
./1D01.hs << EOS
3
4
3
2
EOS
