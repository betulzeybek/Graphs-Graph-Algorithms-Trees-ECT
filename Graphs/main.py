import networkx as nx
import matplotlib.pyplot as plt

G = nx.DiGraph()
list_nodes = [0, 1, 2, 3, 4]
G.add_nodes_from(list_nodes)

list_arcs = [(0, 1, 5), (0, 2, 3), (0, 4, 2), (1, 2, 2), (1, 3, 6), (2, 1, 1), (2, 3, 2), (4, 1, 6), (4, 2, 10), (4, 3, 4)]
G.add_weighted_edges_from(list_arcs)

print("Node 4' ün Node 1' e Dijkstra uzaklığı = ", nx.dijkstra_path(G, 4, 1, weight='weight'))
print("Node 4' ün Node 2' e Dijkstra uzaklığı = ", nx.dijkstra_path(G, 4, 2, weight='weight'))
print("Node 4' ün Node 3' e Dijkstra uzaklığı = ", nx.dijkstra_path(G, 4, 3, weight='weight'))

G.nodes[0]['pos'] = (4, 7)
G.nodes[1]['pos'] = (6, 4)
G.nodes[2]['pos'] = (5, 1)
G.nodes[3]['pos'] = (3, 1)
G.nodes[4]['pos'] = (2, 4)

node_pos = nx.get_node_attributes(G, 'pos')
arc_weight = nx.get_edge_attributes(G, 'weight')
node_col = ['white']
edge_col = ['black']

nx.draw_networkx(G, node_pos, with_labels=True, node_size=1500, node_color=node_col, edge_color=edge_col)
nx.draw_networkx_edge_labels(G, node_pos, edge_labels=arc_weight)
plt.axis('off')
plt.show()

G.remove_node(2)
nx.draw_networkx(G, node_pos, with_labels=True, node_size=1500, node_color=node_col, edge_color=edge_col)
nx.draw_networkx_edge_labels(G, node_pos)
plt.axis('off')
plt.show()





