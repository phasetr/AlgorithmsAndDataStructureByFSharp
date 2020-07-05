#!/bin/bash
chmod +x 1B01.hs
cat << EOS
RESULT 21
======
EOS
./1B01.hs << EOS
147 105
EOS
