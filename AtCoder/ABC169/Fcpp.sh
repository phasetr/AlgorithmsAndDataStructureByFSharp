#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o F.out ABC169F.cpp
echo "=================="
echo "ANSWER"
echo "6"
echo "RESULT"
./F.out < F1.txt
echo "=================="
echo "ANSWER"
echo "0"
echo "RESULT"
./F.out < F2.txt
echo "=================="
echo "ANSWER"
echo "3296"
echo "RESULT"
./F.out < F3.txt
echo "=================="
