FROM node:16-alpine AS build
WORKDIR /app

COPY package.json /app
RUN npm install
RUN npm install -g @angular/cli

COPY . /app
RUN ng build

FROM nginx:1.23.4-alpine
COPY --from=build /app/dist/front-end/ /usr/share/nginx/html
COPY ./nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 81
CMD nginx -g "daemon off;"