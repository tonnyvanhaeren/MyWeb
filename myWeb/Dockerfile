FROM registry.access.redhat.com/rhel7

RUN yum install -y libunwind licicu && yum clean all

ADD bin/release/netcoreapp2.0/rhel.7.4-x64/publish/. /opt/app-root/src/

WORKDIR /opt/app-root/src/

EXPOSE 5000 

CMD ["/bin/bash", "-c", "/opt/app-root/src/myWeb"]