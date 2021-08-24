# README
## docker command
```sh
docker compose up -d
docker compose exec cpp sh
docker compose kill
```

## Run C++
```sh
docker compose exec cpp sh
cd /home/cpp/src
g++ 040.cpp -o 040.out ; ./040.out < 040.txt
```

```sh
docker compose exec cpp sh
cd /home/cpp/src
make 040
```
