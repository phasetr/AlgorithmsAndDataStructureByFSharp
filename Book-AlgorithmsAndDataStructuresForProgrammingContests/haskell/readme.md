# README
## docker commands
```sh
docker compose up -d
docker compose exec hs sh
docker compose kill
```

## Run Haskell
```sh
docker compose exec hs sh
cd /home/hs
stack build
stack exec sample
```

```sh
docker compose exec hs bash -c "stack run sample"
docker compose exec hs bash -c "stack exec sample"
```
