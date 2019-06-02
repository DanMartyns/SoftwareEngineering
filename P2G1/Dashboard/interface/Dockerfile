# base image
FROM node:9.6.1

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

COPY package.json ./usr/src/app/package.json
RUN npm install --silent

CMD npm install react-smoothie
#To bundle your app’s source code inside the Docker image, use the COPY instruction:
COPY . .

CMD ["npm", "start"]
