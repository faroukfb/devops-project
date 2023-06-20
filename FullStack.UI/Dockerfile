# Stage 1: Build the Angular application
FROM node:16-alpine AS build
WORKDIR /app

# Copy the application source code
COPY . .

# Update npm to the latest version
RUN npm install -g npm@latest

# Install dependencies and build the application
RUN npm ci
RUN npm run build

# Stage 2: Serve the application using Nginx
FROM nginx:alpine

# Copy the built application from the previous stage
COPY --from=build /app/dist/full-stack.ui/ /usr/share/nginx/html

# Expose port 80 for the application
EXPOSE 80
