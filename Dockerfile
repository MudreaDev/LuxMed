FROM nginx:alpine

# Copiază toate fișierele statice
COPY index.html /usr/share/nginx/html/
COPY LuxMed.WEB/Content/ /usr/share/nginx/html/Content/
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]