oc new-build --binary --name=web
oc start-build web --from-dir=. --follow
oc set probe dc/web --readiness --get-url=http://5001
oc new-app web
oc expose service web