// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_A/review/5353315/tatyam/C++
#include <iostream>
#include <boost/multiprecision/cpp_int.hpp>

int main(){
  boost::multiprecision::cpp_int a, b;
  std::cin >> a >> b;
  std::cout << a + b << std::endl;
}
