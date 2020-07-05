#!/bin/bash
chmod +x 1A01.hs
cat << EOS
RESULT
5 2 4 6 1 3
2 5 4 6 1 3
2 4 5 6 1 3
2 4 5 6 1 3
1 2 4 5 6 3
1 2 3 4 5 6
======
EOS
./1A01.hs << EOS
6
5 2 4 6 1 3
EOS

echo "================================"

cat << EOS
RESULT
1 2 3
1 2 3
1 2 3
======
EOS
./1A01.hs << EOS
3
1 2 3
EOS
