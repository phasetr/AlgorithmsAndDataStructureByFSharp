#!/bin/bash
dotnet build -v q

echo "==============="
echo "ANSWER"
cat << EOS
6
EOS
echo "====="
echo "RESULT"
dotnet bin/Debug/netcoreapp3.1/run.dll < 1.txt

echo "==============="
echo "ANSWER"
cat << EOS
6
EOS
echo "====="
echo "RESULT"
dotnet bin/Debug/netcoreapp3.1/run.dll < 2.txt

echo "==============="
echo "ANSWER"
cat << EOS
3296
EOS
echo "====="
echo "RESULT"
dotnet bin/Debug/netcoreapp3.1/run.dll < 3.txt
