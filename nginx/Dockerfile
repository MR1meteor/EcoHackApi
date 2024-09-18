FROM nginx

RUN apt update && apt add openssl
RUN rm /etc/nginx/conf.d/default.conf && mkdir -p /home/web/www

RUN openssl dhparam -out /etc/ssl/certs/dhparam.pem 2048 &&\
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/certs/self.key -out /etc/ssl/certs/self.crt \
    -subj "/C=RU/ST=Moscow/L=Kremlin/O=Eco Hack/OU=Org/CN=185.68.22.195"

COPY nginx.conf /etc/nginx/nginx.conf
COPY ssl-params.conf /etc/nginx/ssl-params.conf