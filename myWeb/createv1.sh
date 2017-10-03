oc new-build --binary --name=myweb
oc start-build myweb --from-dir=. --follow
oc new-app myweb