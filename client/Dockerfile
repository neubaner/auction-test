FROM node:12.8

WORKDIR /usr/src/app

COPY package.json package-lock.json ./
RUN npm install
RUN npm install @angular/cli --global

COPY . .
ENTRYPOINT [ "ng", "serve", "--host", "0.0.0.0"]
