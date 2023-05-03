FROM node:16-alpine AS build
WORKDIR /app

COPY package.json /app
RUN npm install

COPY . /app
RUN npm run build

# Serve Application using Nginx Server
FROM nginx:alpine
COPY --from=build /app/dist/front-end/ /usr/share/nginx/html