#!/bin/bash

sudo docker pull davidedwards12/bucstop

sudo docker-compose up --no-deps -d bucstop

sudo docker image prune -f
