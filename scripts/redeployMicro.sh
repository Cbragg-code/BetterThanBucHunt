#!/bin/bash

sudo docker pull davidedwards12/gamemicroserver

sudo docker-compose up --no-deps -d micro

sudo docker image prune -f
