FROM openjdk:12-jdk-alpine
COPY target/wf-0.0.1-SNAPSHOT.jar /usr/wf-0.0.1-SNAPSHOT.jar
ENTRYPOINT ["java","-jar","/usr/wf-0.0.1-SNAPSHOT.jar", "--spring.profiles.active=container"]