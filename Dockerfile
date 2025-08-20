FROM nginx:alpine

# Copiază fișierele
COPY index.html /usr/share/nginx/html/
COPY nginx.conf /etc/nginx/nginx.conf
COPY LuxMed.WEB/Content /usr/share/nginx/html/Content

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]