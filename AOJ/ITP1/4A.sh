#!/bin/bash
chmod +x 4A.hs
cat << EOS
RESULT 1 1 1.50000
EOS
./4A.hs << EOS
3 2
EOS
