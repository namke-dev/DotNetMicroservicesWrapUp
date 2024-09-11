# Load Balancer

is a nerworking device / software that help destributes and balance the incomming request traffic among the servers

improve: availability/ performance/ efficienct

Usercase:
- Single point failure: prevent when a server is down so the whole application is interrupted
-> become unavailable for the users for a period
- Overloaded servers -> add more server and forward the request to the cluster of servers

# I. Feature
- Traffic Distribution: distribute requests among multiple servers
- Provide high availability: when a server down, LB redirects traffic to a healthy server
- Scalability: facilitate horizontal scaling
- Optimize resource
- Health monitoring
- Handle SSL/TLS encryption and decryption

# II. Type of load balancer
## 1. Software Load Balancers in client
- This the cheapest way to implement LB
- the ideal is the application chooses the first one in the list and requests data from the server. if failure occurs persistently in server, it redirect to anotuer server from the list
## 2. Software Load Balancers in server
- the ideal is when the server receive a set of requests and redirect these requests according to a set of rules
## 3. Hardware Load Balancers
- known as Layer 4-7 Routers
- forward the request from client to appropriate server
## 4. Virtual Load Balancers
- is a type of load balancing solution implemented as a virtual machine (VM) or software instance within a virtualized environment 

# III. Types of Static Load Balancing Algorithms
- Round Robin: distribute the request sequentially across a list of server (server 1 -> server 2 -> server 3 -> .. ->server 1)
- Weighted Round-Robin: similar to round robun, but each server is assigned a wieght point. Server has high weight point will receive more request
- Source IP hash: has to cliend IP Address to determine which server will handle the request

# IV. Types of Dynamic Load Balancing Algorithms
- Least Connection Method: redirect to the server which has fewest connection at the time
- Least Response Time Method: redirect to the server which has fastest response time
