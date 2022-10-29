# SacrificeGameJam
\documentclass[10pt,conference,compsocconf]{IEEEtran}

\usepackage{hyperref}
\usepackage{graphicx}	% For figure environment
\usepackage{verbatim}
\usepackage{pdfpages}
\usepackage{hyperref}


\begin{document}
\title{Machine Learning Course - Project 1
}

\author{
  Team °Cloud: Farouk Boukil, Albin Vernhes, Juliette Parchet\\
  \textit{Fall 2022}
}

\maketitle

\newcommand{\bestAccuracy}{75,75\%}

\begin{abstract}
   In this project we implement a classifier to label some particles as Higgs bosons or not. We base our method on logistic regression using gradient descent, after an in-depth data analysis and processing. We achieve a test accuracy of \bestAccuracy.
\end{abstract}

\section{Introduction}
For this work, we use real-world data from CERN about particle accelerators to detect the presence of a Higgs boson in a physical experiment\footnote{To know more about the physic experiment and the dataset background, we invite you to read the report \href{https://higgsml.lal.in2p3.fr/files/2014/04/documentation_v1.8.pdf}{\emph{Learning to discover: the Higgs boson machine learning challenge}}}. 
The dataset consists of 250'000 experiments, each one described by a maximum of 30 features.
\par Our goal is that given the vector of features linked to the experiment, we classify with the best accuracy on a test set the experiment in two categories: the presence of the Higgs boson, or its absence. The binary classifier that we use is the logistic regression using gradient descent.

\par Before applying this method, we do some exploratory data analysis to better understand our dataset and features. Then we perform feature processing and engineering to clean our dataset and extract more meaningful information. Finally, we implement and train the logistic regression machine learning method on a training set, analyze our model and generate predictions on a test set, with accuracy \bestAccuracy.

\section{Models and Methods}

\subsection{Exploratory data analysis}
In the Jupyter Notebook $data\_processing.ipynb$, we perform an analysis of all the experiment features. We remove the outlier values $-999$, which correspond to the fillers, and replace them with TODO. 
\par Then we look in detail at each of the feature independently, to analyze their correlation (HERE DESCRIBE CRITERION TO KEEP/DISCARD FEATURE).

%\begin{figure}[ht]
%\includegraphics[width=\linewidth]{histogram0.pdf}
%\caption{Title of my figure which is displayed in the list %of figures}
%\end{figure}


\subsection{Feature processing and engineering}
 After performing this feature processing, we decide to keep only these features and drop all the others: 
  \begin{itemize}
    \item DER\_mass\_MMC
    \item DER\_mass\_transverse\_met\_lep
    \item DER\_mass\_vis
    \item DER\_pt\_ratio\_lep\_tau
    \item (PRI\_tau\_pt)
    \end{itemize}

% The removed features have been taken out from the report
\begin{comment} 
    \newline And we decided to drop these features: 
      \begin{itemize}
    \item DER\_sum\_pt
    \item PRI\_lep\_eta
    \item PRI\_tau\_eta
    \item PRI\_met\_sumet
    \item PRI\_met
    \item deltar\_tau\_lep
    \item 100\% drop
    \item DER\_pt\_h
    \item DER\_met\_phi\_centrality
    \item PRI\_tau\_phi
    \item PRI\_lep\_phi
    \item PRI\_lep\_pt
    \item PRI\_met\_phi
    \item DER\_mass\_jet\_jet
    \item DER\_deltaeta\_jet\_jet
    \item DER\_lep\_eta\_centrality
    \item DER\_pt\_tot
    \end{itemize}
\end{comment}

\subsection{Comparisons of some classifier methods}

% TODO Name to replace

\subsubsection{1st method}
% TODO

\subsubsection{2nd method}
% TODO

\subsubsection{Logistic regression}
% TODO 
\ 
\par The binary classifier that we use is the logistic regression using gradient descent, with accuracy \bestAccuracy.



\section{Results}
% TODO : clear summary of the quantitative results in one place. You could include a table that evaluates all your contributions (outlier removal, nan handling, polynomial expansion, ...) one by one, so the reader can see which of them were important.

\section{Summary}



\section*{Acknowledgements}

\end{document}


