#!/bin/bash
ROBOT_ID='9aeef9d2-aed3-41b5-7151-08dc528774b2'
URL_BASE="http://localhost:9999/robots/$ROBOT_ID"
VERSION=0
TOKEN_JWT='eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjZlNTZiZDYyLTk4OTctNDI0ZS1iYzRjLTAwYzk5NzM1MWMyOCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImFkbWluQGVtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzEyMDg4NDcyLCJpc3MiOiJodHRwczovL3JvYm90LWFwaSIsImF1ZCI6Imh0dHBzOi8vcm9ib3QtYXBpIn0.1R21o4iMTjoWAWKN1bp-A510QGRS3wjQ1Wpl3tgSOEs'

while true; do
    curl "$URL_BASE" \
        -X 'PUT' \
        -H 'Accept-Language: pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7' \
        -H "Authorization: Bearer $TOKEN_JWT" \
        -H 'Connection: keep-alive' \
        -H 'Content-Type: application/json' \
        --data-raw "{\"name\": \"Maverik UP\"}" ;

    VERSION=$((VERSION+1))
    echo $VERSION
done
