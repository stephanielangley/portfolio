# backend

connect to the server
`ssh steph-1`

## GitHub Actions Runner

cd into the runner folder `cd actions-runner`

start the runner service
`sudo ./svc.sh start`

status of runner service
`sudo ./svc.sh status`

stop runner service
`sudo ./svc.sh stop`

uninstall runner service
`sudo ./svc.sh uninstall`

## running and serving the backend locally

-`cd /api`

- `docker build . -t api`
- `docker run -p 8080:8080 api`

above steps replaced with `docker compose up`

- http://localhost:8080/api
