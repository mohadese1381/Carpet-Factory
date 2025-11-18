# Carpet Factory Simulation (Java)

An algorithmically-driven simulation of a carpet manufacturing workflow, developed for the *Design and Analysis of Algorithms* course.  
This project emphasizes complexity-aware design, OOP modeling, scheduling heuristics, and optimization of production pipelines.

---

## 🚀 Overview

The system models a carpet factory where orders pass through multiple processing stages — including material preparation, pattern processing, weaving, finishing, and packaging.  
Each stage is executed through algorithmically optimized workflows, using custom scheduling and task-allocation strategies.

---

## 🧩 Architecture

The project is structured using clean OOP principles:

```

CarpetFactory
├── OrderManager
│     ├── Order Queue
│     └── Priority Rules
├── MachineController
│     ├── Machines
│     └── Availability Tracking
├── WorkflowEngine
│     ├── Task Generator
│     ├── Recursive Handlers
│     └── Scheduling Unit
└── ReportingModule
├── Time Report
└── Cost Report

```

---

## 🔍 Algorithms & Technical Highlights

### **1. Scheduling Heuristics**
Used to assign machines/workers to tasks:
- Greedy selection for earliest-available resource  
- Minimization of idle time  
- Priority-based job ordering  

### **2. Divide-and-Conquer**
Applied when a carpet is composed of multiple patterned blocks:
- Split → Process → Merge  
- Allows parallel-style conceptual modeling  

### **3. Recursive Workflow Simulation**
Simulates multi-step processing stages:
- Each stage calls the next depending on machine availability  
- Clean state propagation  

### **4. Custom Data Structures**
- Job queues  
- Machine-state arrays  
- Production graphs  

### **5. Complexity-Driven Design**
Core functions implemented with explicit time/space optimization.

---

## 📊 Complexity Summary

| Module / Function                   | Approach               | Time Complexity     |
|-------------------------------------|------------------------|---------------------|
| Machine Assignment Scheduler        | Greedy + min-selector | **O(n log n)**      |
| Block-based Pattern Processing      | Divide & Conquer      | **O(n log n)**      |
| Recursive Stage Simulation          | Depth-based recursion | **O(k)** per stage  |
| Order Prioritization                | Priority Queue        | **O(log n)**        |

---

## 🔄 Production Workflow (Diagram)

```

Input Order
↓
Material Preparation
↓
Pattern Processing (Divide & Conquer)
↓
Weaving Stage (Machine Scheduling)
↓
Finishing
↓
Quality Check
↓
Packaging
↓
Output Report

````

---

## 🛠 Technologies
- Java  
- Recursive & Iterative Algorithm Design  
- Scheduling Heuristics  
- OOP Architecture  
- Custom Data Structures  

---

## ▶️ How to Run

```bash
git clone https://github.com/your-repo/Carpet-Factory
cd Carpet-Factory
javac *.java
java Main
````

---

## 🎓 Project Context

* **Course:** Design and Analysis of Algorithms
* **Year:** 2023
* **Focus:** Algorithmic optimization, workflow simulation, complexity-aware design

---

## 📌 Notes

This project was designed with an emphasis on producing clean algorithmic structure and demonstrating practical applications of scheduling and divide-and-conquer in real-world workflow modeling.
