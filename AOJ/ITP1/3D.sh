#!/bin/bash
chmod +x 3D.hs
cat << EOS
RESULT 3
EOS
./3D.hs << EOS
5 14 80
EOS
