// https://atcoder.jp/contests/ABC086/tasks/abc086_a
// https://qiita.com/drken/items/fd4e5e3630d0f5859067#%E7%AC%AC-1-%E5%95%8F--abc-086-a---product-100-%E7%82%B9
#include <iostream>
using namespace std;

int main()
{
    int a, b;
    cin >> a >> b;
    int c = a * b;
    if (c % 2 == 0)
        cout << "Even" << endl;
    else
        cout << "Odd" << endl;
}
